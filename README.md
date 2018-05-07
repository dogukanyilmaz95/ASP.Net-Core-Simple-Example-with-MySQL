# ASP.Net-Core-Simple-Example-with-MySQL
## This is a Node.js module available through the npm registry.

## Before installing, download and install Node.js. Node.js 0.6 or higher is required.

## Installation is done using the npm install command:
```
$ npm install mysql
```
## For information about the previous 0.9.x releases, visit the v0.9 branch.

## Sometimes I may also ask you to install the latest version from Github to check if a bugfix is working. In this case, please do:
```
$ npm install mysqljs/mysql
```
# Introduction
## This is a node.js driver for mysql. It is written in JavaScript, does not require compiling, and is 100% MIT licensed.

## Here is an example on how to use it:
```
var mysql      = require('mysql');
var connection = mysql.createConnection({
  host     : 'localhost',
  user     : 'me',
  password : 'secret',
  database : 'my_db'
});

connection.connect();

connection.query('SELECT 1 + 1 AS solution', function (error, results, fields) {
  if (error) throw error;
  console.log('The solution is: ', results[0].solution);
});

connection.end();
```
## From this example, you can learn the following:

## Every method you invoke on a connection is queued and executed in sequence.
## Closing the connection is done using end() which makes sure all remaining queries are executed before sending a quit packet to the mysql server.


### Change connection string   
```
optionsBuilder.UseMySQL("server=localhost;user=******;password=*******;persistsecurityinfo=True;database=stockcontrol;SslMode=none");
optionsBuilder.UseSqlServer(@"Data Source=***********\********;Initial Catalog=StokTakip;Integrated Security=True;User ID=*******;Password=******");
```
