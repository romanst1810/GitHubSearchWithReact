import axios from 'axios';

export class GithubApi {
    displayName = GithubApi.name

   static search(text) {
        return axios.get('api/github/search/' + text)
            .then(response => response.data);
    }
}