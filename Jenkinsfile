def PROJECT_NAME = "Calculator" // Khai báo biển tên Tool để sử dụng ở dưới
def WORKSPACE_DIR = "E:\\Jenkins\\.jenkins\\workspace\\${env.JOB_BASE_NAME}"
def CREDENTIAL_ID = 'github_cre' // Thông tin đã đăng ký trong phần tạo Credentials_ID
def SCM_URL = "https://github.com/huongle212/demoJenkins-pipeline.git" // Link source
def SOLUTION_NAME='Calculator'
def PUBLISHER='HuongLT'
def VERSION = "2.0.0.${BUILD_NUMBER}"

pipeline {
    environment {
        // Publish Informations
        localPublishDir = "E:\\OJT\\Winform\\Publish\\${PROJECT_NAME}\\"
        localPublish = "../${PROJECT_NAME}/"
        installUrl="http://localhost:2021/${PROJECT_NAME}/"

    }
    agent any 
    
    stages {
        stage('Set Enviroments') {
            steps {
                script {
                   // VERSION= "2.0.0.${BUILD_NUMBER}"
                }
            }
        }
        stage('Checkout GIT') {
            steps {
                cleanWs()
                checkout([
                    $class: 'GitSCM', 
                    branches: [[name: "*/${GIT_BRANCH.split("/")[1]}"]], 
                    doGenerateSubmoduleConfigurations: false, 
                    extensions: [[$class: 'CloneOption', noTags: true, reference: ""]],
                    gitTool: 'jgitapache', submoduleCfg: [], 
                    userRemoteConfigs: [[credentialsId: "${CREDENTIAL_ID}", url: "${SCM_URL}"]]
                ])
            }
        }
        stage('Build Code') {
            steps {
                // build project by msbuild
                bat "\"${tool 'MSBuild'}\" /t:Restore,Rebuild,Publish \"${SOLUTION_NAME}.sln\" /p:Configuration=Release  /p:ToolsDllPath=dll /p:PublishDir=${localPublishDir},ApplicationVersion=${VERSION},PublisherName=\"${PUBLISHER}\",ProductName=\"${PROJECT_NAME}\",InstallUrl=\"${installUrl}\",UpdateUrl=\"${installUrl}\" /verbosity:quiet"
                // Create index.html file
                writeFile file: 'createIndex.ps1', text: """
                    ((Get-Content -path "E:\\OJT\\Winform\\index.html" -Raw) -replace '{product name}','${PROJECT_NAME}' -replace '{publisher name}','${PUBLISHER}' -replace '{app version}','${VERSION}')|Set-content -path "${localPublishDir}index.html"
                """
                bat 'Powershell.exe -executionpolicy remotesigned -File createIndex.ps1'
            }
        }
        
    }
}
