def PROJECT_NAME = "Calculator" // Khai báo biển tên Tool để sử dụng ở dưới
def WORKSPACE_DIR = "E:\\Jenkins\\.jenkins\\workspace\\${env.JOB_BASE_NAME}"
def CREDENTIAL_ID = 'huongle212+lth0810@_' // Thông tin đã đăng ký trong phần tạo Credentials_ID
def SCM_URL = "https://github.com/huongle212/demoJenkins-pipeline.git" // Link source
def BRANCH = ""
def MSBUILD_PATH="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"

pipeline {
    environment {
        // Publish Informations
        localPublishOnDisk = "E:\\OJT\\Winform\\Publish\\${PROJECT_NAME}\\"
        localPublish = "../${PROJECT_NAME}/"
    }
    agent any 
    
    stages {
        stage('Set Enviroments') {
            steps {
                script {
                    BRANCH = "${GIT_BRANCH.split("/")[1]}"
                }
            }
        }
        stage('Checkout GIT') {
            steps {
                cleanWs()
                checkout([
                    $class: 'GitSCM', 
                    branches: [[name: "*/${BRANCH}"]], 
                    doGenerateSubmoduleConfigurations: false, 
                    extensions: [[$class: 'CloneOption', noTags: true, reference: ""]],
                    gitTool: 'jgitapache',
                    submoduleCfg: [], userRemoteConfigs: [[credentialsId: "${CREDENTIAL_ID}", url: "${SCM_URL}"]]
                ])
            }
        }
        stage('Build Code') {
            steps {
                echo "Build Code"
                // Create Build file
                writeFile file: 'build.bat', text: """
                    "${MSBUILD_PATH}" /t:Clean /verbosity:quiet
                    :: MSBuild.exe /t:Restore /verbosity:quiet
                    "${MSBUILD_PATH}" /t:Restore,Rebuild,Publish "${PROJECT_NAME}.sln" /p:Configuration=Release  /p:ToolsDllPath=dll /p:PublishDir=${localPublishOnDisk} /verbosity:quiet
                """
            }
        }
    }
}
