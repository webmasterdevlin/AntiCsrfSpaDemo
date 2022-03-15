import Cookies from "js-cookie";
import axios from "axios";

const api = axios.create({
    baseURL:"api/"
});

api.interceptors.request.use((requestConfig) => {
    const cookie = Cookies.get("XSRF-TOKEN");
    if (cookie && cookie.length) {
        requestConfig.headers.common["X-XSRF-TOKEN"] = cookie
    }

    return requestConfig;
});

export { api };

