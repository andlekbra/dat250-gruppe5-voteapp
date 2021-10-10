package no.hvl.dat250.gruppe5.voteapp.controller;

import no.hvl.dat250.gruppe5.voteapp.models.VoterProfile;
import no.hvl.dat250.gruppe5.voteapp.services.VoterProfileServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping(path = "api/voterprofiles")
public class VoterProfileController {

    private final VoterProfileServices voterService;

    @Autowired
    public VoterProfileController(VoterProfileServices voterService) {
        this.voterService = voterService;
    }

    @GetMapping
    public List<VoterProfile> getVoters() {
        return voterService.getVoters();
    }

    @GetMapping(path = "{voterId}")
    public Optional<VoterProfile> findVoterById(@PathVariable() Long voterId) {
        return voterService.getVoter(voterId);
    }

    @PostMapping
    public void registerNewVoter(@RequestBody VoterProfile voter) {
        voterService.addNewVoter(voter);
    }

    @DeleteMapping
    public void deleteVoter(@RequestParam("voterId") Long voterID) {
        voterService.deleteVoter(voterID);
    }

    @PutMapping(path = "{voterId}")
    public void updateVoter(@PathVariable("voterId") Long voterId, @RequestParam(required = false) String username,
            @RequestParam(required = false) String email, @RequestParam(required = false) String firstName,
            @RequestParam(required = false) String lastName) {
        voterService.updateVoter(voterId, username, email, firstName, lastName);
    }
}