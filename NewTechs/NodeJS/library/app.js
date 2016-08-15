var express = require('express');
var bodyParser = require('body-parser');
var cookieParser = require('cookie-parser');
var passport = require('passport');
var session = require('express-session');
var app = express();

var port = process.env.PORT || 5000;

var nav = [{
    Link: '/Books',
    Text: 'Books'
        }, {
    Link: '/Authors',
    Text: 'Authors'
        }];

var bookRouter = require('./src/routes/bookRoutes')(nav);
var adminRouter = require('./src/routes/adminRoutes')(nav);
var authRouter = require('./src/routes/authRoutes')(nav);

app.use(express.static('public'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded());
app.use(cookieParser());
app.use(session({secret:'library'}));
require('./src/config/passport')(app);

app.set('views', './src/views');
app.set('view engine', 'ejs');


app.use('/Books', bookRouter);
app.use('/Admin',adminRouter);
app.use('/Auth',authRouter);

var mssql = require('mssql');
var config = {
    user: 'booklogin',
    password: 'admin123+',
    server: 'DELL\\SQLEXPRESS',
    database: 'Books',
    options: {
        encrypt: false
    }
};

mssql.connect(config,function(err){
    console.log(err);
});


app.get('/', function (req, resp) {
    resp.render('index', {
        title: 'MyAPP',
        nav: nav
    });
});


app.listen(port, function (err) {
    console.log('Running server on port ' + port);
});