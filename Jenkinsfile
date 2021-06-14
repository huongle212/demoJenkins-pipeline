def CREDENTIAL_ID = 'huongle212+lth0810@_' // Thông tin đã đăng ký trong phần tạo Credentials_ID
def SCM_URL = "https://github.com/huongle212/demoJenkins-pipeline.git" // Link source
def BRANCH = ""

pipeline {
    agent any 
    
    stages {
        stage('Set Enviroments') {
            steps {
                script {
                    BRANCH = "${GIT_BRANCH.split("/")[1]}"
                    echo "${BRANCH}"
                }
            }
        }
        stage('Checkout GIT') {
            steps {
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
                    cd ${WORKSPACE_DIR}\\${codeDir}\\
                    MSBuild.exe /t:Clean /verbosity:quiet
                    nuget restore
                    :: MSBuild.exe /t:Restore /verbosity:quiet
                    MSBuild.exe /t:Restore,Rebuild,Publish /p:Configuration=Release  /p:ToolsDllPath=dll /p:PublishDir=${localPublishOnDisk}\\${PROJECT_NAME}\\ /verbosity:quiet
                """
            }
        }
    }
}
