package nta.med.service.integration.nuro;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OUT0101U02ImportPatientTest extends MessageRequestTest {

	@Test
	public void testImportPatient() throws Exception {
		
		List<NuroModelProto.OUT0101U02ImportPatientInfo> lstPt = new ArrayList<NuroModelProto.OUT0101U02ImportPatientInfo>();
		for (int i = 0; i < 5; i++) {
			String bunho = "BIDV" + i;
			NuroModelProto.OUT0101U02ImportPatientInfo info = NuroModelProto.OUT0101U02ImportPatientInfo.newBuilder()
					.setSex("F")
					.setBunho(bunho)
					.setSuname("T NAME 01U")
					.setSuname2("T NAME 02UXY")
					.setBirth("1999/01/01")
					.setZipCode("12345678")
					.setTel("12345678")
					.setBunhoType("1")
					.setAddress1("Addr1")
					.setAddress1("Addr2")
					.setAddress1("Addr3")
					.build();
			
			//lstPt.add(info);
		}
		
		NuroModelProto.OUT0101U02ImportPatientInfo info = NuroModelProto.OUT0101U02ImportPatientInfo.newBuilder()
				.setSex("M")
				.setBunho("000005714")
				.setSuname("T NAME 01U")
				.setSuname2("T NAME 02UXY")
				.setBirth("1999/01/01")
				.setZipCode("12345678")
				.setTel("12345678")
				.setBunhoType("1")
				.setAddress1("Addr1")
				.setAddress1("Addr2")
				.setAddress1("Addr3")
				.build();
		lstPt.add(info);
		
		NuroServiceProto.OUT0101U02ImportPatientRequest request = NuroServiceProto.OUT0101U02ImportPatientRequest.newBuilder()
		.addAllPatients(lstPt)
		.setUserId("10323")
		.setIgnoreDuplicate(true)
		.build();

		sentRequestToMedApp(request, NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
