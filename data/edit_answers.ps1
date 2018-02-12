$passphrase = Convert-Path ~\.travis-passphrase
$plaintext = "$PSScriptRoot\Answers.txt"
$cyphertext = "$PSScriptRoot\Answers.txt.gpg"

if(Test-Path $plaintext) { rm $plaintext }
gpg --batch --passphrase-file $passphrase --output $plaintext --decrypt $cyphertext
$before = Get-Content $plaintext | git hash-object -w --stdin
nano $plaintext
$after = Get-Content $plaintext | git hash-object -w --stdin
if(Test-Path $cyphertext) { rm $cyphertext}
gpg --batch --passphrase-file $passphrase --output $cyphertext --symmetric $plaintext


git diff $before $after --word-diff