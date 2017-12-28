package nta.med.orca.gw.model.system;

import nta.med.service.ihis.proto.SystemModelProto;

/**
 * @author dainguyen.
 */
public interface Patient {

    SystemModelProto.PatientInfo toPatientProto();

    String getName1();

    void setName1(String name1);

}
