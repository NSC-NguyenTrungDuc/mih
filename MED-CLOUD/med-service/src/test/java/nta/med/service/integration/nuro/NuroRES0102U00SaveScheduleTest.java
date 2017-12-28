package nta.med.service.integration.nuro;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NuroRES0102U00SaveScheduleTest extends MessageRequestTest{

    @Test
    public void testUpdateStatusPatientItemRequest() throws Exception {
    	List<NuroModelProto.NuroRES0102U00GrdRES0102Info> list = new ArrayList<NuroModelProto.NuroRES0102U00GrdRES0102Info>();
    	
    	NuroModelProto.NuroRES0102U00GrdRES0102Info.Builder item1 =  NuroModelProto.NuroRES0102U00GrdRES0102Info.newBuilder();
    	item1.setDoctor("01K01OCS");
    	item1.setJinryoBreakYn("N");
    	item1.setStartDate("2017/02/15");
		item1.setEndDate("2017/02/16");
    	item1.setDataRowState("Added");
    	item1.setGwa("01");
    	list.add(item1.build());
    	
    	/*NuroModelProto.NuroRES0102U00GrdRES0102Info.Builder item2 =  NuroModelProto.NuroRES0102U00GrdRES0102Info.newBuilder();
    	item2.setDoctor("HuanLT");
    	item2.setJinryoBreakYn("N");
    	item2.setStartDate("2016/02/18");
    	item2.setDataRowState("Add");
    	item2.setGwa("01");
    	list.add(item2.build());
    	
    	
    	NuroModelProto.NuroRES0102U00GrdRES0102Info.Builder item3 =  NuroModelProto.NuroRES0102U00GrdRES0102Info.newBuilder();
    	item3.setDoctor("HuanLT");
    	item3.setJinryoBreakYn("N");
    	item3.setStartDate("2016/02/15");
    	item3.setDataRowState("Add");
    	item3.setGwa("01");
    	list.add(item3.build());
    	
    	
    	NuroModelProto.NuroRES0102U00GrdRES0102Info.Builder item4 =  NuroModelProto.NuroRES0102U00GrdRES0102Info.newBuilder();
    	item4.setDoctor("HuanLT");
    	item4.setJinryoBreakYn("N");
    	item4.setStartDate("2016/02/22");
    	item4.setGwa("01");
    	item4.setDataRowState("Add");
    	list.add(item4.build());
    	
    	NuroModelProto.NuroRES0102U00GrdRES0102Info.Builder item5 =  NuroModelProto.NuroRES0102U00GrdRES0102Info.newBuilder();
    	item5.setDoctor("HuanLT");
    	item5.setJinryoBreakYn("N");
    	item5.setStartDate("2016/02/20");
    	item5.setDataRowState("Add");
    	item5.setGwa("01");
    	list.add(item5.build());*/
    	
    	NuroServiceProto.NuroRES0102U00SaveScheduleRequest request = NuroServiceProto.NuroRES0102U00SaveScheduleRequest.newBuilder().setHospCode("K01")
    			.addAllGridRes0102SaveItem(list)
    			.setUserId("HuanLT")
    			.build();

		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
				getOptions().getExtension(Rpc.service));
	}
}
