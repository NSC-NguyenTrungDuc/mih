package nta.med.service.integration.ihis;

import java.util.ArrayList;
import java.util.List;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U04GetPatientStatusListItemInfo;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0503U00gridOSC0503ListInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class OCS0503U00SaveLayoutHandlerTest extends MessageRequestTest{

    @Test
    public void testUpdateStatusPatientItemRequest() throws Exception {
    	List<OCS0503U00gridOSC0503ListInfo> list = new ArrayList<OCS0503U00gridOSC0503ListInfo>();
    	
    	OCS0503U00gridOSC0503ListInfo.Builder item1 =  OCS0503U00gridOSC0503ListInfo.newBuilder();
    	
    	//{bunho: "000001164" req_date: "2015/12/26" req_gwa: "01" req_doctor: "01K01OCS" pkocs0503: "165" 
    	//consult_gwa: "01" consult_doctor: "0110002" consult_sang_name: "\343\202\204\343\201\233" in_out_gubun: "O" 
    	//fkinp1001: "0" confirm_yn: "N" jinryo_pre_date: "2015/12/28" reser_time: "0000" display_yn: "Y" 
    	//consult_gwa_name: "\345\206\205\347\247\221" consult_doctor_name: "DOC" req_gwa_name: "\345\206\205\347\247\221" 
    	//req_doctor_name: "\345\260\217\346\236\227" row_state: "Added" } user_id: "K01OCS"
    	item1.setBunho("000001164");
    	item1.setReqDate("2015/12/26");
    	item1.setReqGwa("01");
    	item1.setReqDoctor("01K01OCS");
    	item1.setPkocs0503("165");
    	item1.setConsultGwa("01");
    	item1.setConsultDoctor("0110002");
//    	item1.setConsultSangName("\343\202\204\343\201\233");
    	item1.setInOutGubun("O");
    	item1.setFkinp1001("0");
    	item1.setConfirmYn("N");
    	item1.setJinryoPreDate("2015/12/28");
    	item1.setReserTime("0000");
    	item1.setDisplayYn("Y");
//    	item1.setConsultGwaName("\345\206\205\347\247\221");
    	item1.setConsultDoctorName("DOC");
//    	item1.setReqGwaName("\345\206\205\347\247\221");
//    	item1.setReqDoctorName("\345\260\217\346\236\227");
    	item1.setRowState("Added");
    	
    	list.add(item1.build());
    	
    	
    	OcsaServiceProto.OCS0503U00SaveLayoutRequest request = OcsaServiceProto.OCS0503U00SaveLayoutRequest.newBuilder()
    			.addAllGrdOcs0503Item(list)
    			.setUserId("K01OCS")
    			.build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
