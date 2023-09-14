import React, { Component, useState } from "react";
import { useLocation } from "react-router-dom";
import { Navbar, Container, Nav, Dropdown, Button } from "react-bootstrap";
import './Navbar.css';

import routes from "../../routes.js";
import showToastMessage from "../../utils/ShowSuccess";

function Header() {
  const [isOpen, setIsOpen] = useState(false);

  const location = useLocation();
  const mobileSidebarToggle = (e: any) => {
    e.preventDefault();
    document.documentElement.classList.toggle("nav-open");
    var node = document.createElement("div");
    node.id = "bodyClick";
    node.onclick = () => {
      node.parentElement?.removeChild(node);
      document.documentElement.classList.toggle("nav-open");
    };

    document.body.appendChild(node);
  };

  const getBrandText = () => {
    for (let i = 0; i < routes.length; i++) {
      if (location.pathname.indexOf(routes[i].layout + routes[i].path) !== -1) {
        return routes[i].name;
      }
    }
    return "Brand";
  };
  return (
    <Navbar bg="light" expand="lg">
      <Container fluid>
        <div className="d-flex justify-content-center align-items-center ml-2 ml-lg-0">
          <Button
            variant="dark"
            className="d-lg-none btn-fill d-flex justify-content-center align-items-center rounded-circle p-2"
            onClick={mobileSidebarToggle}
          >
            <i className="fas fa-ellipsis-v"></i>
          </Button>
          <Navbar.Brand
            href="#home"
            onClick={(e) => e.preventDefault()}
            className="mr-2"
          >
            {getBrandText()}
          </Navbar.Brand>
        </div>
        <Navbar.Toggle
          aria-controls="basic-navbar-nav"
          className={`mr-2 ${isOpen ? 'toggled' : ''}`}
          onClick={() => setIsOpen(!isOpen)}
        >
          <span className="navbar-toggler-bar burger-lines"></span>
          <span className="navbar-toggler-bar burger-lines"></span>
          <span className="navbar-toggler-bar burger-lines"></span>
        </Navbar.Toggle>

        <Navbar.Collapse id="basic-navbar-nav" className={isOpen ? 'open' : ''}>
          <Nav className="nav mr-auto" navbar>
            {/* <Nav.Item>
              <Nav.Link
                data-toggle="dropdown"
                href="#"
                onClick={(e) => e.preventDefault()}
                className="m-0"
              >
                <i className="nc-icon nc-button-play"></i>
                <span className="d-lg-none ml-1">Cartelera</span>
              </Nav.Link>
            </Nav.Item> */}
            <Dropdown as={Nav.Item}>
              <Dropdown.Toggle
                as={Nav.Link}
                data-toggle="dropdown"
                id="dropdown-67443507"
                variant="default"
                className="m-0"
              >
                <i className="nc-icon nc-planet"></i>
                <span className="notification">5</span>
                <span className="d-lg-none ml-1">Notification</span>
              </Dropdown.Toggle>
              <Dropdown.Menu>
                <Dropdown.Item
                  href="#"
                  onClick={(e) => e.preventDefault()}
                >
                  Notification 1
                </Dropdown.Item>
                <Dropdown.Item
                  href="#"
                  onClick={(e) => e.preventDefault()}
                >
                  Notification 2
                </Dropdown.Item>
                <Dropdown.Item
                  href="#"
                  onClick={(e) => e.preventDefault()}
                >
                  Notification 3
                </Dropdown.Item>
                <Dropdown.Item
                  href="#"
                  onClick={(e) => e.preventDefault()}
                >
                  Notification 4
                </Dropdown.Item>
                <Dropdown.Item
                  href="#"
                  onClick={(e) => e.preventDefault()}
                >
                  Another notification
                </Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
            <Nav.Item>
              <Nav.Link
                className="m-0"
                href="#"
                onClick={(e) => e.preventDefault()}
              >
                <i className="nc-icon nc-zoom-split"></i>
                <span className="d-lg-block"> Buscar</span>
              </Nav.Link>
            </Nav.Item>
          </Nav>
          <Nav className="ml-auto" navbar>
            <Nav.Item>
              <Nav.Link
                className="m-0"
                href="#"
                onClick={(e) => e.preventDefault()}
              >
                <span className="no-icon">Cuenta</span>
              </Nav.Link>
            </Nav.Item>
            <Nav.Item>
              <Nav.Link
                className="m-0"
                href="#"
                onClick={(e) => {
                  e.preventDefault();

                  showToastMessage({
                    title: "Logout correcto",
                    icon: "success",
                    callback: () => {
                      //navigate("/login");
                    },
                  });
                }}
              >
                <span className="no-icon">Log out</span>
              </Nav.Link>
            </Nav.Item>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default Header;
