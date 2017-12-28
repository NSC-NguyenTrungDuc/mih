package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00ProcessInsertTest extends MessageRequestTest{
	@Test
	public void test() throws Exception{
		
		NuriServiceProto.NUR2004U00ProcessInsertRequest request = NuriServiceProto.NUR2004U00ProcessInsertRequest.newBuilder()
				.setUserId("")
				.setFkinp1001("1606729")
				.setBunho("000032256")
				.setTransCnt("2")
				.setOrderDate("")
				.setFromGwa("")
				.setToGwa("")
				.setFromDoctor("")
				.setToDoctor("")
				.setFromResident("")
				.setToResident("")
				.setFromHoCode1("")
				.setFromHoDong1("")
				.setToHoCode1("")
				.setToHoDong1("")
				.setFromKaikeiHodong("")
				.setFromKaikeiHocode("")
				.setToKaikeiHocode("")
				.setToKaikeiHodong("")
				.setFromHoCode2("")
				.setFromHoDong2("")
				.setToHoCode2("")
				.setToHoDong2("")
				.setTransGubun("")
				.setFromBedNo("")
				.setToBedNo("")
				.setToBedNo2("")
				.setToHoGrade1("")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
