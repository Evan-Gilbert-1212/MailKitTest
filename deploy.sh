docker build -t MailKitTest-image .

docker tag MailKitTest-image registry.heroku.com/MailKitTest/web


docker push registry.heroku.com/MailKitTest/web

heroku container:release web -a MailKitTest