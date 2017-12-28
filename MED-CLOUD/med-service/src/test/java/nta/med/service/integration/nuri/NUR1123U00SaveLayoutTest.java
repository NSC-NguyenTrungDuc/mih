package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR1123U00SaveLayoutTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception {
		
		NuriModelProto.NUR1123U00grdDetailInfo.Builder info = NuriModelProto.NUR1123U00grdDetailInfo.newBuilder()
				.setCodeType("010")
				.setCode("003")
				.setCodeName("kkkkkkkkk")
				.setSortKey("3")
				.setRowState("Modified")
				;
				
		
		NuriServiceProto.NUR1123U00SaveLayoutRequest.Builder request = NuriServiceProto.NUR1123U00SaveLayoutRequest.newBuilder()
				.addGrd(info.build())
				.setUserId("10323");
				
		sentRequestToMedApp(request.build(), NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
