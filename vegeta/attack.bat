@echo off

set duration = "30s"
set rate = 100

echo ####################### STATUS CODE 200 #######################

echo NO EXCEPTIONS
vegeta.exe attack -targets no-exceptions-success.target -duration %duration % -rate %rate % | vegeta.exe report

echo WITH EXCEPTIONS
vegeta.exe attack -targets with-exceptions-success.target -duration %duration % -rate %rate % | vegeta.exe report

echo ###############################################################



echo ####################### STATUS CODE 400 #######################

echo NO EXCEPTIONS
vegeta.exe attack -targets no-exceptions-fail.target -duration %duration % -rate %rate % | vegeta.exe report

echo WITH EXCEPTIONS
vegeta.exe attack -targets with-exceptions-fail.target -duration %duration % -rate %rate % | vegeta.exe report

echo ###############################################################