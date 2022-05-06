# Push Net.API into ECR with Pulumi

This project is an example on how we can build the infrastructure with pulumi, build and push an image into Aws ECR.

### Requirements
* [Install Pulumi](https://www.pulumi.com/docs/get-started/install/)
* [Create an AWS account](https://aws.amazon.com/resources/create-account/)
* Create an User from IAM
  * Get it's `Access_Key_Id`
  * Get it's `Secret_Access_Key`
* Create an S3 Bucket, to [login it with pulumi](https://aws.amazon.com/resources/create-account/)

## Setup locally

To run locally first you need to have some environment variables:
```
$env:AWS_ACCESS_KEY_ID = "[AwsAccessKeyId]"
$env:AWS_SECRET_ACCESS_KEY = "[AwsSecretAccessKey]"
$env:AWS_REGION="["RegionOfChoice"]"
```
You need now to login with pulumi into the S3, that you should have created before.
```
pulumi login s3://<Bucket-Name>
```

Create a new Pulumi project
```
pulumi new aws-csharp
```

Apply the changes incode into AWS (this will create the ECR and provides an output of the ECR Url)
```
pulumi up
```
If you don't want to be asked everytime the passphrase you need to create a new env variable and assign the desire password into it.
`$env:PULUMI_CONFIG_PASSPHRASE = "SecretPassphrase"`

Displays a password that you can use with a container client of your choice to authenticate to any Amazon ECR registry that your IAM principal has access to.
```
aws ecr get-login-password --region ["RegionOfChoice"]
```

Make docker login into the AWS account with the ECR that was created before. It will prompt to enter the password that was created in the previous step.
```
sudo docker login --username AWS [EcrUrl]
```

Build the image and push it into ECR
```
sudo docker build -t ecr-sample-dmr-dev .

sudo docker tag ecr-sample-dmr-dev:latest 577020306328.dkr.ecr.eu-central-1.amazonaws.com/ecr-sample-dmr-dev:latest

sudo docker push 577020306328.dkr.ecr.eu-central-1.amazonaws.com/ecr-sample-dmr-dev:latest
```

## Run with Github Actions

You can select the workflow `Push into ECR` and select `run workflow` into the main branch. the following steps/jobs will happen.

* Build: It will build with it's dependencies of the whole solution
* Pulumi preview: It will run `pulumi preview` and returns a summary with the difference between the state of the code with the one that is on the S3 bucket.
* Pulumi up: It will run `pulumi up` and apply the changes that are on the code.
* Build and Push: It will setup the credentials of AWS, Login into AWS and finally it will build/push the image into the ECR that was created in the previous job.

This workflow, has already setup in it's `secrets` the variables that will be used across the workflow, like `AWS_ACCESS_KEY_ID`, `AWS_SECRET_ACCESS_KEY`, `AWS_PULUMI_STATE_S3_BUCKET_NAME`, among others.