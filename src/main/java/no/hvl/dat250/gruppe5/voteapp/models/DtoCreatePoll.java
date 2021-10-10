package no.hvl.dat250.gruppe5.voteapp.models;

import java.sql.Time;

import lombok.Data;

@Data
public class DtoCreatePoll {
    private Long pollTemplateId;
    private String name;
    private Time startTime;
    private Time stopTime;
    private boolean isPrivate;
}