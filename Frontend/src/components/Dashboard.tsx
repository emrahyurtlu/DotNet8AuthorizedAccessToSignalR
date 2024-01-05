import { HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr"
import axios from "axios"
import _ from "lodash"
import { useEffect, useState } from "react"
import { Button, Col, Container, Row } from "react-bootstrap"
type Forecast = {
  date: string
  temperatureC: number
  temperatureF: number
  summary: string
}
const Dashboard = () => {
  const token = sessionStorage.getItem("accessToken")
  const [data, setData] = useState<Array<Forecast>>()
  const [value, setValue] = useState("")
  const [calculationResult, setCalculationResult] = useState(null)
  const [connection, setConnection] = useState<HubConnection>()

  useEffect(() => {
    createHubConnection()
  }, [])

  const createHubConnection = async () => {
    const hubCn = new HubConnectionBuilder()
      .withUrl("http://localhost:5034/hub", {
        headers: { Authorization: `Bearer ${token}` },
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
      })
      .configureLogging(LogLevel.Critical)
      .withAutomaticReconnect()
      .build()
    await hubCn.start()
    setConnection(hubCn)
  }

  useEffect(() => {
    connection?.on("ReceiveRootOfNumber", (result) => {
      setCalculationResult(result)
    })
  }, [connection])

  const dataHandler = () => {
    axios
      .get<Array<Forecast>>("http://localhost:5034/WeatherForecast", { headers: { Authorization: `Bearer ${token}` } })
      .then((result) => {
        setData(result.data)
      })
      .catch((reason) => console.log(reason))
  }

  const calculateSquareRoot = async () => {
    await connection?.invoke("GetSquareRootAsync", value)
  }

  return (
    <Container>
      <Row>
        <Col>
          <h3 className="mt-5">List Wheather Forecast Via Classical Api</h3>
          {data != null && (
            <ul>
              {data.map((item) => (
                <li key={_.uniqueId()}>
                  <div>
                    <div>Date: {item.date}</div>
                    <div>TemperatureC: {item.temperatureC}</div>
                    <div>TemperatureF: {item.temperatureF}</div>
                    <div>Summary: {item.summary}</div>
                  </div>
                </li>
              ))}
            </ul>
          )}
          <div className="d-grid">
            <Button onClick={dataHandler}>Load Data</Button>
          </div>
        </Col>
        <Col>
          <h3 className="mt-5">Call SignalR Hub</h3>
          <div className="my-2">
            Connection Status: <strong>{connection?.state}</strong>
          </div>
          <div>
            <input type="number" className="form-control" onChange={(e) => setValue(e.target.value)} />
          </div>
          <div className="mt-2 d-grid">
            <Button onClick={calculateSquareRoot}>Calculate Square Root</Button>
          </div>
          <div className="mt-3">{calculationResult != null && <h1>Result: {calculationResult}</h1>}</div>
        </Col>
      </Row>
    </Container>
  )
}

export default Dashboard
