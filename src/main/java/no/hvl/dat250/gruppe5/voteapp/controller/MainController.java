package no.hvl.dat250.gruppe5.voteapp.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class MainController {

    @RequestMapping("/")
    public String index(){
        return "/index";
    }
}
