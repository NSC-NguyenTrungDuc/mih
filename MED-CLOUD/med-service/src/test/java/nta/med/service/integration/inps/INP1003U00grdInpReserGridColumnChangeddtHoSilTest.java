package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author vnc.tuyen
 */
public class INP1003U00grdInpReserGridColumnChangeddtHoSilTest extends MessageRequestTest {
	@Test
	public void test () throws Exception{
		InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilRequest request = InpsServiceProto.INP1003U00grdInpReserGridColumnChangeddtHoSilRequest.newBuilder()
				.setHospCode("323")
				.setHoCodeYmd("2017/01/01")
				.setHoDong("%")
				.setHoCode("T69")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
