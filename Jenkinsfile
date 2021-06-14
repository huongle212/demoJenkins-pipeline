def SCM_URL = "https://github.com/huongle212/demoJenkins-pipeline.git" // Link source

pipeline {
    agent any 
    
    stages {
        stage('Clone') { 
            steps {
                ["git", "clone", "${SCM_URL}"].execute()
            }
        }
    }
}
