package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00ProcessUpdateTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NUR2004U00ProcessUpdateRequest request = NuriServiceProto.NUR2004U00ProcessUpdateRequest.newBuilder()
				.setUserId("10323")
				.setToHoDong2("")
				.setToHoCode2("")
				.setToBedNo("02")
				.setToBedNo2("")
				.setToHoGrade1("00")
				.setToKaikeiHodong("")
				.setToKaikeiHocode("")
				.setToHoDong1("17")
				.setToHoCode1("T77")
				.setTransCnt("1")
				.setToDoctor("0110323")
				.setFkinp1001("63")
				.setToGwa("01")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
