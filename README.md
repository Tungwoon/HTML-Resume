# Cloud Resume Challenge in Azure 

Tung Hor's Resume URL: https://www.thewoons.life/


**Introduction**

Challenges:
- Created a GitHub repository
- Created a HTML website and styled in CSS
- Deployed as Azure Storage Static Website 
- Enabled HTTPS and Azure CDN to Custom Domain
- Included Javascript visitor counter on the website
- Created Azure Functions with HTTP Trigger 
- Azure Functions API linked to CosmoDB database
- CI/CD (Front end) with Github Actions 


Next Improvements:
- Create functions API with Python
- Create Test modules with Python
- Deploy API resources with Terraform
- CI/CD (Backend) with Github Actions (currently have error)



**Important Steps and Commands**

Github Setup
1. Set up Github account and create a new repository.
2. Clone the code with ssh in Github, switch over to desktop CLI and type: git clone git@github.com:...
3. Change to the file folder and start working the development file.  

*Git commands*
1. git init  ##tracking the folder changes
2. git status  ##to list changes file 
3. git add . or git add -A  ##to add all or particular file 
4. git commit -m "comment"  ##to confirm the version with a message, --amend to commit to the same version
5. git push  ##to push to Github repository
6. git pull  ##pull file from Github repository
7. git log  ##version history
8. git reset . ##reset the changes


Azure Cosmo DB, Statis Website, HTTPS and CDN
1. Cosmo DB for NoSQL API and Capacity mode: Serverless
2. Create new database as 'AzureResume' and new container as 'Counter'
3. Add new item and under id partition key, changed to "1", and add another field "count" : 0  --> save
4. Next deploy the static website (HTML) into Azure storage account, index.html will be stored in blob storage.
5. In Azure portal storage account, on the left panel click 'Static Website', endpoint URL is located here.
6. Create a new endpoint in Azure CDN with static website hostname, after created add a new custom domain.
7. After mapping to new custom domain completed, select the custom domain URL to configure enable domain HTTPS and default certificate settings.


Azure Functions and API
1. Create a new function app in the same resource group 
2. Deploy as code with Node.js runtime stack, version 16 in the region closer to you. Windows OS and Serverless consumption to minimise cost.
3. Once created, create a new "HTTP Trigger" function.
4. Under Integration, add input and output binding or refer to function.json in my Github backend api folder.
5. In Code + Test, refer to my index.js file in Github backend api folder.
6. Obtain the function URL and paste it to website frontend main.js file.
7. Update custom domain and static website URL in CORS under function App.


CI/CD Frontend
1. Create a new ".github" directory and under that directory create another directory "workflows" 
2. Create a secret to be stored in Github. In Azure CLI, key in command: az ad sp create-for-rbac --name AzureResumexxx --role Contributor --scopes /subscriptions/[00000000-0000-0000-0000-000000000000]/resourceGroups/[resourceGroup1]/ --sdk-auth
3. Copy the Json and go to Github repository setting, under Secrets, create a new repository secret and paste the Json value.
4. Look for Microsoft documentary "Use Github Actions workflow to deploy your static website in Azure Storage"
https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blobs-static-site-github-actions?tabs=userlevel
5. Copy the full code and paste in frontend.yml file, make a few changes. Refer to my Github sample.
6. Git add . + git commit -m "added fronted yml" + git push
7. Make some changes in index.html and git push to the repository. You will see the changes reflected in custom domain without manually changing the contents.
8. Go to Github/Repository/Actions to check progress/action.

I will blog the steps taken in detail soon, or reach out to me in linkedIn. Thank you!
 






