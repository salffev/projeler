import requests
import json
#coder by salffev.

def get_twitter_login_url():
    """
    Returns the Twitter login URL.
    """
    return "https://api.twitter.com/oauth2/authorize?client_id=YOUR_CLIENT_ID&redirect_uri=YOUR_REDIRECT_URI&scope=YOUR_SCOPE"

def get_twitter_access_token(code):
    """
    Returns the Twitter access token.
    """
    params = {
        "grant_type": "authorization_code",
        "code": code,
        "client_id": "YOUR_CLIENT_ID",
        "client_secret": "YOUR_CLIENT_SECRET",
        "redirect_uri": "YOUR_REDIRECT_URI"
    }

    response = requests.post("https://api.twitter.com/oauth2/token", params=params)

    if response.status_code == 200:
        data = json.loads(response.content.decode("utf-8"))
        return data["access_token"], data["token_type"], data["expires_in"]
    else:
        raise Exception("Error getting Twitter access token: {}".format(response.status_code))

def get_twitter_user_info(access_token):
    """
    Returns the Twitter user information.
    """
    headers = {
        "Authorization": "Bearer {}".format(access_token)
    }

    response = requests.get("https://api.twitter.com/1.1/users/show.json", headers=headers)

    if response.status_code == 200:
        data = json.loads(response.content.decode("utf-8"))
        return data["name"], data["screen_name"], data["profile_image_url"]
    else:
        raise Exception("Error getting Twitter user info: {}".format(response.status_code))

if __name__ == "__main__":
    # Get the Twitter login URL.
    login_url = get_twitter_login_url()

    # Redirect the user to the Twitter login page.
    print("Please log in to Twitter.")
    print(login_url)

    # Get the user's code from the Twitter login page.
    code = input("Please enter the code from the Twitter login page: ")

    # Get the user's access token.
    access_token, token_type, expires_in = get_twitter_access_token(code)

    # Get the user's information.
    name, screen_name, profile_image_url = get_twitter_user_info(access_token)

    print("Welcome, {}!".format(name))
    print("Your screen name is: {}".format(screen_name))
    print("Your profile image URL is: {}".format(profile_image_url))
