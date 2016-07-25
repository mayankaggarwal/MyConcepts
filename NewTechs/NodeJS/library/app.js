var express = require('express');

var app = express();

var port = process.env.PORT || 5000;

var bookRouter = express.Router();

app.use(express.static('public'));
app.set('views', './src/views');
app.set('view engine', 'ejs');

bookRouter.route('/')
    .get(function (req, resp) {
        resp.render('Books',{
        title: 'MyAPP',
        nav: [{
            Link: '/Books',
            Text: 'Books'
        }, {
            Link: '/Authors',
            Text: 'Authors'
        }]
    });
});

bookRouter.route('/Single')
    .get(function (req, resp) {
        resp.send('Hello Single Book');
    });

app.use('/Books',bookRouter);


app.get('/', function (req, resp) {
    resp.render('index', {
        title: 'MyAPP',
        nav: [{
            Link: '/Books',
            Text: 'Books'
        }, {
            Link: '/Authors',
            Text: 'Authors'
        }]
    });
});

app.get('/Books', function (req, resp) {
    resp.send('Hello Books');
});

app.listen(port, function (err) {
    console.log('Running server on port ' + port);
});