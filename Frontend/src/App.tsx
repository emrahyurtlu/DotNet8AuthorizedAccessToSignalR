import React from "react"
import { Col, Container, Row } from "react-bootstrap"
import { RouterProvider, createBrowserRouter } from "react-router-dom"
import Dashboard from "./components/Dashboard"
import LoginForm from "./components/LoginForm"
import WelcomePage from "./components/WelcomePage"

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <WelcomePage />,
    },
    {
      path: "/dashboard",
      element: <Dashboard />,
    },
    {
      path: "/login",
      element: <LoginForm />,
    },
    {
      path: "/register",
      element: <LoginForm />,
    },
  ])
  return (
    <React.Fragment>
      <Container>
        <Row>
          <Col>
            <RouterProvider router={router} />
          </Col>
        </Row>
      </Container>
    </React.Fragment>
  )
}

export default App
