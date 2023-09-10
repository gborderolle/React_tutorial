import React from "react";
import { actorDTO } from "./actor.model";
import { Container, Row, Col, Card } from "react-bootstrap";
import { urlGenres } from "../../utils/endpoints";
import IndexEntity from "../global/IndexEntity";

export default function IndexActors() {
  return (
    <>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">
              <Card.Header>
                <Card.Title as="h4">Striped Table with Hover</Card.Title>
                <p className="card-category">
                  Here is a subtitle for this table
                </p>
              </Card.Header>
              <Card.Body className="table-full-width table-responsive px-0"></Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </>
  );
}
