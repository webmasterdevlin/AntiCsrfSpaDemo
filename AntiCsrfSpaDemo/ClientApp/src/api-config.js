import axios from "axios";

const api = axios.create({
    baseURL:"api/"
});

api.interceptors.request.use((requestConfig) => {
    const cookie = getCookie("XSRF-TOKEN");
    if (cookie && cookie.length) {
        requestConfig.headers.common["X-XSRF-TOKEN"] = cookie
    }
    return requestConfig;
});

export { api };

export function getCookie(key) {
    const regExpString = `(?:(?:^|.*;\\s*)${key}\\s*=\\s*([^;]*).*$)|^.*$`
    const regExp = new RegExp(regExpString)
    return decodeURIComponent(document.cookie.replace(regExp, '$1'))
}