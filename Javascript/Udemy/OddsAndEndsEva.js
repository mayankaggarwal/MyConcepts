// Initialization
var people = [
    {
        //The Mayank object
        firstname : 'mayank',
        lastname : 'Aggarwal',
        addresses : [
            '111 Main St.',
            '222 third St.'
        ]
    },
    {
        // The John object
        firstname : 'John',
        lastname : 'Doe',
        addresses : [
            'Kahmiri Mohalla',
            'Kharsa road'
        ],
        greet : function() {
            return 'Hello!';
        }
    }
]

log(people);