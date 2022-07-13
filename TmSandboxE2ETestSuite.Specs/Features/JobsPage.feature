Feature: Jobs Page

@mytag
Scenario: Open a job from the job carousel
	Given the starting page is the jobs page
	And the job named Sales Manager is present on the carousel
	When I click the Sales Manager job
	Then the job details page is opened