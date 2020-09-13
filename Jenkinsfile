pipeline {
	
	agent any
	
	stages {
	
		stage("build") {
		
			steps {
				bat '"C:\\ProgramData\\chocolatey\\bin\\nuget.exe" restore C:\\Projetos\\SysTeam\\backend\\backend.sln'
			}
		}
	
		stage("test") {
		
			steps {
				bat 'dotnet build C:\\Projetos\\SysTeam\\backend\\Test'
			}
			steps {
				bat 'dotnet test C:\\Projetos\\SysTeam\\backend\\Test\\bin\\Debug\\netcoreapp3.1\\Test.dll'
			}
		}
	
		stage("deploy") {
		
			steps {
				echo 'deploying the application...'
			}
		}
	}
}
