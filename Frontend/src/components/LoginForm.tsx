import axios from "axios"
import { useState } from "react"
import { Button, Col, Form, Row } from "react-bootstrap"
import { useNavigate } from "react-router-dom"

const LoginForm = () => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const navigate = useNavigate()

  const loginHandler = () => {
    if (email != null && password != null) {
      //http://localhost:5034/login?useCookies=true
      axios
        .post("http://localhost:5034/login", { email, password })
        .then((result) => {
          console.log(result)
          sessionStorage.setItem("accessToken", result.data.accessToken)
          sessionStorage.setItem("refreshToken", result.data.refreshToken)
          sessionStorage.setItem("tokenType", result.data.tokenType)
          navigate("/dashboard")
        })
        .catch((reason) => {
          console.log(reason)
        })
    }
  }
  return (
    <Form className="mt-5">
      <Form.Group as={Row} className="mb-3" controlId="formPlaintextEmail">
        <Form.Label column sm="2">
          Email
        </Form.Label>
        <Col sm="10">
          <Form.Control placeholder="email@example.com" onChange={(e) => setEmail(e.target.value)} />
        </Col>
      </Form.Group>

      <Form.Group as={Row} className="mb-3" controlId="formPlaintextPassword">
        <Form.Label column sm="2">
          Password
        </Form.Label>
        <Col sm="10">
          <Form.Control type="password" placeholder="Password" onChange={(e) => setPassword(e.target.value)} />
        </Col>
      </Form.Group>

      <Form.Group as={Row} className="mb-3" controlId="formPlaintextPassword">
        <Col sm="12">
          <Button variant="primary" onClick={loginHandler}>
            LOGIN
          </Button>
        </Col>
      </Form.Group>
    </Form>
  )
}

export default LoginForm
