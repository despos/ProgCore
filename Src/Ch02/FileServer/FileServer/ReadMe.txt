THIS DEMO IS QUITE MINIMAL AND IS *NOT* A FULL SITE.

Therefore you can't just run it and expect it to work as it has no UI and no default page.

1) Launch it selecting FileServer from the BUILD menu or IIS Express. You'll get 404
   because there's no default page defined and no default endpoint. The app only serves a few specific 
   requests.
2) Type http://localhost:5000/index.html. 
3) Type http://localhost:5000/public/assets/test.jpg.