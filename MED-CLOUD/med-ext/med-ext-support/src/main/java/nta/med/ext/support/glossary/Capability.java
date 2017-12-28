package nta.med.ext.support.glossary;

import nta.med.ext.support.proto.SystemServiceProto;

/**
 * @author dainguyen.
 */
public enum Capability {
    CREATE_PATIENT(1), BOOK_EXAM(2), APPOINT_EXAM(3), GET_MIS_TOKEN(4), ORDER_TRANSFER(5), GET_MIS_SURVEY_LINK(6);

    private final int value;

    Capability(int value) {

        this.value = value;
    }

    public SystemServiceProto.LoginRequest.Capability toProto() {
        return SystemServiceProto.LoginRequest.Capability.valueOf(value);
    }
}
