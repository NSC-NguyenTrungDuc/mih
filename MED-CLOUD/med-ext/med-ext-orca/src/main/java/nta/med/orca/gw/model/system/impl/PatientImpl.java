package nta.med.orca.gw.model.system.impl;

import nta.med.orca.gw.model.system.Patient;
import nta.med.service.ihis.proto.SystemModelProto;

/**
 * @author dainguyen.
 */
public class PatientImpl implements Patient {

    private String name1;

    public static Patient valueOf(SystemModelProto.PatientInfo patientProto){
        Patient patient = new PatientImpl();
        patient.setName1(patientProto.getPatientName1());

        return patient;
    }

    @Override
    public SystemModelProto.PatientInfo toPatientProto() {
        SystemModelProto.PatientInfo.Builder builder = SystemModelProto.PatientInfo.newBuilder()
                .setPatientName1(name1);
        return builder.build();
    }

    @Override
    public String getName1() {
        return this.name1;
    }

    @Override
    public void setName1(String name1) {
        this.name1 = name1;
    }
}
