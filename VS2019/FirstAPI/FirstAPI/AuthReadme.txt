Passing token in header via jQuery:
1) Using beforeSend:

$.ajax({
	url: 'https://api.sandbox.slcedu.org/api/rest/v1/students/test1',
	type: 'GET',
	beforeSend: function (xhr) {
		xhr.setRequestHeader('Authorization', 'Bearer t-7614f875-8423-4f20-a674-d7cf3096290e');
	},
	data: {},
	success: function () { },
	error: function () { },
});

2) Specify with "headers" key:
var settings = {
    "url": "https://api.example.com/action",
    "method": "POST",
    "headers": {
        "Content-Type": "application/json",
        "Authorization": "Bearer eyJraWQiOiJBbWZJSXU3UFhhdXlUbHM3UmNyZmNIQUd1MUdCWkRab2I0U05GaVJuWUFJPSIsImFsZyI6IlYYYjU2In0.eyJzdWIiOiJjNTYyEEE1ZS05Zjc3LTQ2NDAtYTFmOS1hJJJ5Njk1OGE0MzUiLCJhdWQiOiI3Z2ZsZnNmMm1vNnQ4dXJpOG0xcHY5N3BnayIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJldmVudF9pZCI6ImE2YWFjOTQxLTYzYWUtNGU5ZS1iYTE1LTRlYTNlOGIyZjQ5MSIsInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNTY4OTY0NDI2LCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAudXMtd2VzdC0yLmFtYXpvbmF3cy5jb21cL3VzLXdlc3QtMl9qanRiZFZkZEYiLCJjb2duaXRvOnVzZXJuYW1lIjoiYzU2MmFjNWUtOWY3Ny00NjQwLWExZjktYTgxOTY5NThhNDM1IiwiZXhwIjoxNTY4OTY4MDI2LCJpYXQiOjE1Njg5NjQ0MjcsImVtYWlsIjoiYnJ5YW5Ab3BlbndvbmsuY29tIn0.fV4bgaKwXx-HjrBmGtBnSzaDHdP0JEeJ0sbE6MzuOJYWafT5gWfh9pLtkpUv-mgsnX3cVIWDVKC0H8_XM4ziUhsulZIRBwTiSca0CfABvanuMdbdjk1iK70aUxsrjHX0gK4SDUi4Zl6JNGws_SRbVi9Yq_ntx7ttXfUpZHjimfZ2mLidOLUruYctG1V_gU-dLD6CARCUbGh5aRk5nwX_5-HBUTbBVPYK3sXcVg2YRk63d-p3TITA5hoOEj9lxtHs3ZM7ZqNPl0XPUGghxdbvWnpSIUKrFLugRHqCiWxC38ZYiBhP0NDYoEMaOI-UrnEH1W6j-kr3fnH2LD5wOMJ_8Q"
    },
    "data": {
        "someData": someData
    }
}

$.ajax(settings).done(function (response) {
    console.log(response)
})

OR

let token = "token value";
$.ajax({
	url: 'YourRestEndPoint',
	method: 'POST',
	data: JSON.stringify(dataObject),
	contentType: 'application/json',
	headers: {
		'Authorization': `Bearer ${token}`,
	},
	success: function(data){
		console.log('succes: '+data);
	}
});
