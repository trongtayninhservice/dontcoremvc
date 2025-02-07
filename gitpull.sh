GIT_SSH_COMMAND="ssh -i  ../pri.ppk" git pull git@github.com:trongtayninhservice/dontcoremvc.git
echo " git status"
#chờ 3 giây git fetch origin

sleep 3
GIT_SSH_COMMAND="ssh -i  ../pri.ppk"  git status
sleep 3
php8 artisan optimize
sleep 3
