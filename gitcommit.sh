#!/bin/bash

# Check if commit message was supplied
# Check if commit message was supplied
if [ -z "$1" ]
then
    # If not supplied, use current date and time as commit message
    commit_message=$(date '+%Y-%m-%d %H:%M:%S')
else
    commit_message=$1
fi

# Add all changes to staging
git add .

# Commit with supplied message or default message
git commit -m "$commit_message"



# Push changes to remote
# call gitpush.sh
./gitpush.sh
