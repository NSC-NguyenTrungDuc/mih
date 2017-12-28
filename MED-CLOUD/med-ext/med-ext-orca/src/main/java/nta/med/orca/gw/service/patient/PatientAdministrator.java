package nta.med.orca.gw.service.patient;

import nta.med.orca.gw.model.patient.PublicInsurance;
import nta.med.orca.gw.model.patient.PrivateInsurance;
import nta.med.orca.gw.model.patient.SyncPatient;
import nta.med.orca.gw.model.patient.SyncReservation;
import nta.med.orca.gw.model.patient.SyncExamination;

import java.util.List;

/**
 * @author DEV-TiepNM
 */
public interface PatientAdministrator {
    
	public boolean patientSynchronization(SyncPatient syncPatient,
			  List<PublicInsurance> publicInsuranceList,
	    	  List<PrivateInsurance> privateInsuranceList,
	    	  String userId, String hospCode,
	    	  String autoBunhoFlg,
	    	  String orcaGigwanCode) throws Exception;
	
	public boolean patientListSynchronization(List<SyncPatient> syncPatientList,
			  List<PublicInsurance> publicInsuranceList,
	    	  List<PrivateInsurance> privateInsuranceList,
	    	  String userId, String hospCode,
	    	  String autoBunhoFlg,
	    	  String orcaGigwanCode);
	
    public boolean acceptingSynchronization(List<SyncExamination> examList, String hospCode);

    public boolean reservationListSynchronization(List<SyncReservation> syncReservationList, String hospCode);
    
}
