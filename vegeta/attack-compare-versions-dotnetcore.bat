@echo off

set duration = "30s"
set rate = 100

echo ################################# DOTNETCORE1.1 #################################

vegeta.exe attack -targets no-exceptions-core11-success.target -duration %duration % -rate %rate % | vegeta.exe report

echo #################################################################################

echo ################################# DOTNETCORE2.0 #################################

vegeta.exe attack -targets no-exceptions-success.target -duration %duration % -rate %rate % | vegeta.exe report

echo #################################################################################
