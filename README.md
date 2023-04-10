# Cloud Resume Challenge in Azure 
<br>
Tung Hor's Resume URL: https://www.thewoons.life/
<br>
<br>
![Cloud Resume Challenge Diagram](https://user-images.githubusercontent.com/100461340/230848906-56c8ebd3-98ce-46a1-83ab-981c588b1966.png)
<br>
[Cloud Resume Challenge Diagram.pdf](https://github.com/Tungwoon/HTML-Resume/files/11188489/Cloud.Resume.Challenge.Diagram.pdf)  
  
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
2. Clone code with ssh in Github portal, switch over to desktop CLI and type: git clone git@github.com:...
3. Change to the file folder and start working on the development file.  
  
*Git commands*
1. git init  ##tracking the folder changes
2. git status  ##to list changes file 
3. git add . or git add -A  ##to add all OR add only specific file 
4. git commit -m "comment"  ##to confirm the version with a message, --amend to commit to the same version
5. git push  ##to push to Github repository
6. git pull  ##pull file from Github repository
7. git log  ##version history
8. git reset . ##reset the changes
  
  
Azure Cosmo DB, Static Website, CDN and HTTPS
1. Create a new Cosmo DB for NoSQL API with serverless Capacity mode under same resource group.
2. Create the new database account name as "AzureResumeCosmoDB" with serverless capacity mode.
3. Go to Data Explorer on the left panel, create a new container as "AzureResume" and add new item as "Counter". Under id partition key, change value to "1", and add another field "count" : 0  --> save
4. Next deploy the static website (HTML) into Azure storage account, index.html will be stored in blob storage.
5. In Azure portal storage account, on the left panel click 'Static Website', endpoint URL is located here.
6. Create a new endpoint in Azure CDN with static website hostname, after created add a new custom domain.
7. Once mapping is doned, select the custom domain URL to configure "Enable domain HTTPS" with default certificate settings.
  
  
Azure Functions and API
1. Create a new function app with the same resource group 
2. Deploy code with Node.js runtime stack, version 16 in the region closer to you, Windows OS with Serverless consumption to minimise cost.
3. Next, create a new "HTTP Trigger" function.
4. Under Integration on the left panel, add input and output binding, refer to my function.json in Github backend api folder.
5. In Code + Test option on the left panel, write your code or refer to my index.js file in Github backend api folder.
6. Obtain the function URL and paste it in frontend main.js (const functionApi = 'https://getresumecounter....').
7. Lastly go to function app and update custom domain URL and static website URL in CORS.
  
  
CI/CD Frontend
1. Create a new ".github" directory and under that directory create another directory "workflows" 
2. Create a secret to be stored in Github. In Azure CLI, key in command: "az ad sp create-for-rbac --name AzureResumexxx --role Contributor --scopes /subscriptions/[00000000-0000-0000-0000-000000000000]/resourceGroups/[resourceGroup1]/ --sdk-auth"
3. Copy the Json and go to Github portal repository setting. Under Secrets, create a new repository secret with Json value obtained earlier.
4. Next, search online for Microsoft documentary "Use Github Actions workflow to deploy your static website in Azure Storage" https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blobs-static-site-github-actions?tabs=userlevel
5. Copy the full code and paste in frontend.yml file, make a few changes. Refer to my Github sample.
6. Git add . + git commit -m "added fronted yml" + git push
7. Make some changes in index.html and git push to repository. You will see the changes reflected in custom domain without manually changing the contents.
8. Lastly go to Github/Repository/Actions in portal to check progress/action.
    
  
I will blog the steps in detail soon, reach out to me in linkedIn. Thank you!







