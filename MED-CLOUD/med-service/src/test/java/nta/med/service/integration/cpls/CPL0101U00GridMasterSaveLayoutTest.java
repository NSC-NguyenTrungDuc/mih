package nta.med.service.integration.cpls;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CPL0101U00GridMasterSaveLayoutTest extends MessageRequestTest{

	@Test
	public void cPL0101U00GridMasterSaveLayoutTest() throws InterruptedException {
		CplsModelProto.CPL0101U00InitListItemInfo.Builder info = CplsModelProto.CPL0101U00InitListItemInfo.newBuilder();
		info.setHangmogCode("1212");
		info.setEmergency("Y");
		info.setSpecimenCode("01");
		info.setJukyongDate("2016/01/20");
		info.setDataRowState("Added");
		
		CplsServiceProto.CPL0101U00GridMasterSaveLayoutRequest request = CplsServiceProto.CPL0101U00GridMasterSaveLayoutRequest
				.newBuilder()
				.addItemInfo(info)
				.build();    
		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}