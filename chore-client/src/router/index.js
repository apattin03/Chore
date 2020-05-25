
import Vue from 'vue'
import Router from 'vue-router'
import ChoreRecords from '@/components/ChoreRecords'

import Auth from '@okta/okta-vue'
import Hello from '@/components/Hello'

Vue.use(Auth, {
  issuer: 'https://dev-736404.okta.com/oauth2/default',
  client_id: '0oad0tmb9B502IWD54x6',
  redirect_uri: 'http://localhost:8080/implicit/callback',
  scope: 'openid profile email'
})

Vue.use(Router)

let router = new Router({
  mode: 'history',
  routes: [
	{
  	path: '/',
  	name: 'Hello',
  	component: Hello
	},
	{
  	path: '/implicit/callback',
  	component: Auth.handleCallback()
  },
  {
    path: '/chore-records',
    name: 'ChoreRecords',
    component: ChoreRecords,
    meta: {
      requiresAuth: true
    }
  },
  ]
})

router.beforeEach(Vue.prototype.$auth.authRedirectGuard())

export default router