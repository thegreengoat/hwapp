#!/bin/bash
# AWS bash script

# Vars
REPO="hello-world-repository"
TASK_DEF_NAME="hello-world-task-def"
TAG="latest"
VER="v0001"
ACCOUNT_ID="036145437149"


# Create the ECS Repository
function create_repo() {
    if [[ $(aws ecr describe-repositories --repository-names $REPO | jq '.repositories[].repositoryName' | sed s/\"//g) == $REPO ]]; then
        echo "ECS Repository '$REPO' already exists"
    else
        echo "ECS Repository '$REPO' not found, creating..."
        if [[ $(aws ecr create-repository --repository-name $REPO | jq '.repository.repositoryName' | sed s/\"//g) == $REPO ]]; then
            echo "ECS Repository '$REPO' successfully created."
        else
            echo "Failed to create ECS Repository '$REPO'."
            return 1
        fi
    fi
    return 0
}

build_and_push_docker() {
	eval $(aws ecr get-login)
    #if last line == Login Succeeded
    
        docker build -t $REPO .
        #if last line starts with Successfully built

            docker tag $REPO:$TAG $(get_image_name)
            #nil return

            docker push $(get_image_name)
            #if last line starts with $TAG
}

function get_region() {
    echo $(aws configure get region)
}

function get_image_name() {
    echo $ACCOUNT_ID.dkr.ecr.$(get_region).amazonaws.com/$REPO:$VER
}

function myfunc()
{
    local  __resultvar=$1
    local  myresult=1
    eval $__resultvar=$myresult
}

register_task_definition() {
    eval cat './container-defs.json' | jq --arg t "$TASK_DEF_NAME-$VER" '.family = $t' | jq --arg t "$(get_image_name)" '.containerDefinitions[].image = $t' > "./test.json"
    aws ecs register-task-definition --cli-input-json "file://./test.json"
}

#register_task_definition

if create_repo; then 
    build_and_push_docker;
    register_task_definition 
fi
#build_and_push_docker