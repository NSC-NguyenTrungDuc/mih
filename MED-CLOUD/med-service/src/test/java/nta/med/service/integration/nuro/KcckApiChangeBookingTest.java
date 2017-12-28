package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-TiepNM
 */
public class KcckApiChangeBookingTest extends MessageRequestTest {
    {
//        "hosp_code": "K01",
//            "department_code": "01",
//            "doctor_code": "K01OCS",
//            "reservation_date": "2016/03/28",
//            "reservation_time": "0915",
//            "patient_code": "000000010",
//            "patient_name_kanji": "該当",
//            "patient_name_kana": "カルテ",
//            "patient_tel": "0987654321",
//            "patient_email": "000000010@sofiamedix.vn",
//            "patient_sex": "M",
//            "patient_birthday": "1988/10/10",
//            "locale": "ja"
    }

    @Test
    public void test() throws InterruptedException {

        NuroServiceProto.KcckApiBookingRequest request = NuroServiceProto.
                KcckApiBookingRequest.newBuilder()
                .setHospCode("K01").
                        setDepartmentCode("01").
                        setDoctorCode("01K01OCS").
                        setReservationDate("2016/03/30").
                        setReservationTime("0912").
                        setPatientCode("000000010").build();

        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }

}
