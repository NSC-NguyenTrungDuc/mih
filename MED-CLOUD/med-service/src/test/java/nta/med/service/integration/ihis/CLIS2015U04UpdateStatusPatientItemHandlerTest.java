package nta.med.service.integration.ihis;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisModelProto.CLIS2015U04GetPatientStatusListItemInfo;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

public class CLIS2015U04UpdateStatusPatientItemHandlerTest extends MessageRequestTest{

    @Test
    public void testUpdateStatusPatientItemRequest() throws Exception {
    	List<CLIS2015U04GetPatientStatusListItemInfo> list = new ArrayList<CLIS2015U04GetPatientStatusListItemInfo>();
    	
    	CLIS2015U04GetPatientStatusListItemInfo.Builder item1 =  CLIS2015U04GetPatientStatusListItemInfo.newBuilder();
    	item1.setProtocolPatientId("8");
    	item1.setCode("05");
    	//item1.setDescription("descriptions");
    	item1.setUpdateDate("2016/04/27");
    	item1.setRowState("Modified");
    	list.add(item1.build());
    	
    	/*CLIS2015U04GetPatientStatusListItemInfo.Builder item3 =  CLIS2015U04GetPatientStatusListItemInfo.newBuilder();
    	item3.setPatientStatusId("1");
    	item3.setUpdateDate("2015/09/15");
    	item3.setRowState("Modified");
    	list.add(item3.build());
    	
    	CLIS2015U04GetPatientStatusListItemInfo.Builder item4 =  CLIS2015U04GetPatientStatusListItemInfo.newBuilder();
    	item4.setPatientStatusId("2");
    	item4.setUpdateDate("2015/09/15");
    	item4.setRowState("Modified");
    	list.add(item4.build());
    	
    	CLIS2015U04GetPatientStatusListItemInfo.Builder item5 =  CLIS2015U04GetPatientStatusListItemInfo.newBuilder();
    	item5.setPatientStatusId("3");
    	item5.setUpdateDate("2015/09/15");
    	item5.setRowState("Modified");
    	list.add(item5.build());*/
    	
    	
    	ClisServiceProto.CLIS2015U04UpdateStatusPatientItemRequest request = ClisServiceProto. CLIS2015U04UpdateStatusPatientItemRequest.newBuilder()
    			.addAllPatientStatus(list)
    			.build();

        sentRequestToMedApp(request, ClisServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
