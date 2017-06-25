# INTRODUCTION

Our users want insightful statistics from the smart meter data that we receive from them every day. 
UX research and user interviews have shown, that especially monthly aggregates are of the highest interest. 
So as a first step, we want to show users their yearly consumption broken down by calendar month. 

The consumption data is recorded by a smart meter as a cumulative consumption snapshot at 00:00 hours every day. 
While the rest of our team focuses on the DB and rest endpoint logic, we want to implement processing the snapshots for a single smart meter into aggregates. 
*Please see example-ui.png for details*

It can be assumed that: 
- Both input and output series are sorted by time 
- The input series has no gaps 
- The input series can start and end at an arbitrary point in time 

# USER STORIES

"As a user, I want to view my energy usage by month so that I can gain insightful statistics into my usage"
"As a user, I want to view my energy usage between [startdate] and [enddate] so that I can filter out unwanted data""# VCharge" 
