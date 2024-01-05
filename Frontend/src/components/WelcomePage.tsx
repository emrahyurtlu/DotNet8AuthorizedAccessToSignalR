import React, { useEffect } from "react"
import { useNavigate } from "react-router-dom"

const WelcomePage = () => {
  const navigate = useNavigate()
  useEffect(() => {
    const token = sessionStorage.getItem("accessToken")
    if (token == null) {
      navigate("/login")
    } else {
      navigate("/dashboard")
    }
  }, [])
  return <div>WelcomePage</div>
}

export default WelcomePage
