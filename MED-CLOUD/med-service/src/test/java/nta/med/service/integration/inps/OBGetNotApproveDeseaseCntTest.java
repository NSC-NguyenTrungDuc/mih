package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OBGetNotApproveDeseaseCntTest extends MessageRequestTest{

	@Test
	public void test() throws InterruptedException {

		SystemServiceProto.OBGetNotApproveDeseaseCntRequest request = SystemServiceProto.OBGetNotApproveDeseaseCntRequest.newBuilder()
				.setFIoGubun("I")
				.setFInsteadYn("Y")
				.setFApproveYn("Y")
				.setFDoctorId("10323")
				.setFBunho("0000011111")
				.build(); 
		
		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
