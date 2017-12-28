package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INP1003U01fbxInp1003Test extends MessageRequestTest{
	@Test
	public void test () throws Exception{
		InpsServiceProto.INP1003U01fbxInp1003Request request = InpsServiceProto.INP1003U01fbxInp1003Request.newBuilder()
				.setBuseoYmd("2016/11/12")
				.setDoctorYmd("2016/11/12")
				.setNameControl("fbxDoctor33")
				.setGwa("01")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
