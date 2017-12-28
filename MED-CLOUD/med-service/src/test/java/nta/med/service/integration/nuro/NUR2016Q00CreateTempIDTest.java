package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2016Q00CreateTempIDTest extends MessageRequestTest {

	@Test
	public void test() throws Exception{
		
		NuroModelProto.NUR2016Q00CreateTempIDInfo info = NuroModelProto.NUR2016Q00CreateTempIDInfo
				.newBuilder()
				.setBunho("000002832")
				.setHospCode("323")
				.setSuname("")
				.setSuname2("")
				.setBirth("1981-08-09")
				.setLinkPatientFlg("1")
				.setBunhoType("3")
				.setSex("1")
				.build(); 
		
		NuroServiceProto.NUR2016Q00CreateTempIDRequest request = NuroServiceProto.NUR2016Q00CreateTempIDRequest.newBuilder()
				.setOrcaPatient(true)
				.setTempItem(info)
				.build();
		
		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
