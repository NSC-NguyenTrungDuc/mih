package nta.med.service.integration.cpls;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CPL2010U01layBarcodeTempTest extends MessageRequestTest {

	@Test
	public void test() throws InterruptedException {
		CplsServiceProto.CPL2010U01layBarcodeTempRequest request = CplsServiceProto.CPL2010U01layBarcodeTempRequest
				.newBuilder()
				.setBunho("")
				.setJubsuDate("2016/12/27").build();
		
		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		
//		CplsServiceProto.CPL2010U01layBarcodeTemp2Request request = CplsServiceProto.CPL2010U01layBarcodeTemp2Request
//		.newBuilder()
//		.setSpecimenSer("16040800001")
//		.build();
//
//		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
