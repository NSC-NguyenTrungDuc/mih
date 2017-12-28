package nta.mss.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.mss.entity.HospitalTracking;

@Repository
public interface HospitalTrackingRepository extends JpaRepository<HospitalTracking, Integer>, HospitalTrackingRepositoryCustom { 

}
